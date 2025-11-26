def getFuel(value):
    return value // 3 - 2

def recgetFuel(value):
    cost = value // 3 - 2
    if(cost <= 0):
        return 0 
    else:
        return cost + recgetFuel(cost)


with open('input.txt', 'r') as file:
    content = file.read()

lines = content.split('\n')

sum = 0
recSum = 0

for line in lines:
    sum += getFuel(int(line))
    recSum += recgetFuel(int(line))

print(sum)
print(recSum)