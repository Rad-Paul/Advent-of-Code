def drawWire(map, xDiff, yDiff):
    
    return 0

with open('input.txt', 'r') as file:
    content = file.read()

wirePaths = content.split('\n')
wireOne = wirePaths[0].split(',')
wireTwo = wirePaths[1].split(',')

map = []
for i in range(20):
    line = []
    for j in range(20):
        line.append('.')
    map.append(line)

for i in range(len(map)):
    print(map[i])

