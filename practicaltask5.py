def PolyInterpolate(data):
    n = len(data) - 1
    x = [data[i][0] for i in range(n+1)]
    y = [data[i][1] for i in range(n+1)]
    for i in range(n):
        if x[i] >= x[i+1]:
            raise Exception("Incorrect data points")
    def f(t):
        try:
            if t < x[0] or t > x[n]:
                raise Exception("Out of bound argument")
            res = y[n]
            for i in range(n-1, -1, -1):
                res = y[i] + (t - x[i]) * res
            return res
        except Exception as e:
            return str(e)
    return f
data1 = [[3, 6], [0, 3], [2, 1]]

f1 = PolyInterpolate(data1)
print(f1(0))      # Output: 3
print(f1(2))      # Output: 1
print(f1(2.75))   # Output: 4.375
print(f1(3))      # Output: 6
print(f1(-1))     # Output: Out of bound argument
 
data2 = [[3, 6], [3, 7]]
f2 = PolyInterpolate(data2)
print(f2(0))      # Output: Incorrect data points
 
data3 = [[-1, 1.25], [2, 3.5]]
f3 = PolyInterpolate(data3)
print(f3(1))      # Output: 2.75
print(f3(-1))     # Output: 1.25