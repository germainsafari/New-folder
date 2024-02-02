import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from pandas_datareader import data as pdr

# Download historical data (monthly) for DJI constituent stocks
tickers = ["MSFT"]

price_data = []
for ticker in range(len(tickers)):
    prices = pdr.get_data_yahoo(tickers[ticker], 
                                 start="2019-01-01", 
                                 end="2022-12-31", 
                                 interval = "m")
    price_data.append(prices.assign(ticker=ticker)[['Adj Close']])
df_stocks = pd.concat(price_data, axis=1)
df_stocks.columns=tickers
monthly_returns = df_stocks.pct_change()

mean_returns = monthly_returns.mean()
cov_matrix = monthly_returns.cov()
num_iterations = 10000
simulation_res = np.zeros((3+len(tickers)-1,num_iterations))

for i in range(num_iterations):
    # Select random weights and normalize to set the sum to 1
    weights = np.array(np.random.random(4))
    weights /= np.sum(weights)
    # Calculate the return and standard deviation for every step
    portfolio_return = np.sum(mean_returns * weights)
    portfolio_std_dev = np.sqrt(np.dot(weights.T,np.dot(cov_matrix, weights)))
    # Store all the results in a defined array
    simulation_res[0,i] = portfolio_return
    simulation_res[1,i] = portfolio_std_dev
    # Calculate Sharpe ratio and store it in the array
    simulation_res[2,i] = simulation_res[0,i] / simulation_res[1,i]
    # Save the weights in the array
    for j in range(len(weights)):
        simulation_res[j+3,i] = weights[j]

sim_frame = pd.DataFrame(simulation_res.T,columns=['ret','stdev','sharpe',tickers[0],tickers[1],tickers[2],tickers[3]])
plt.scatter(sim_frame.stdev,sim_frame.ret,c=sim_frame.sharpe,cmap='RdYlBu')
plt.colorbar()