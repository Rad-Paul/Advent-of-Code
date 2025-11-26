def getCellPower(j, i, serial):
    rackID = j + 10
    power = rackID * i
    power += serial
    power = power * rackID
    asString = str(power)
    if(len(asString) < 3):
        power = 0
    else:
        power = int(asString[0 + len(asString) - 3])
    power -= 5

    return power

grid = [[0 for _ in range(300)] for _ in range(300)]
serial = 7989
for i in range(300):
    for j in range(300):
        grid[i][j] = getCellPower(j, i, serial)

bestRegion = -999

#answer for part1
topLeftCoords = [0, 0]
for i in range(1, 299):
    for j in range(1, 299):
        power = grid[i][j] + grid[i-1][j] + grid[i-1][j+1] + grid[i][j+1] + grid[i+1][j+1] + grid[i+1][j] + grid[i+1][j-1] + grid[i][j-1] + grid[i-1][j-1]
        if power > bestRegion:
            topLeftCoords[0] = j-1
            topLeftCoords[1] = i-1
            bestRegion = power
print(bestRegion, topLeftCoords)