import numpy as np

def manhattanDist(coords1, coords2):
    return np.abs(coords1[0] - coords2[0]) + np.abs(coords1[1] - coords2[1])

with open('input.txt', 'r') as file:
    points = []
    content = file.read().split('\n')
    for line in content:
        coords = line.split(', ')
        points.append([int(coords[0]), int(coords[1])])
maxX, maxY = 0, 0
for pt in points:
    if pt[0] > maxX:
        maxX = pt[0]
    if pt[1] > maxY:
        maxY = pt[1]

w, h = maxX, maxX
grid = np.zeros((w,h), dtype=str)
territories = {}
infTerritories = set()
#for part2
#find the size of the region that has a total distance to all coordinates less than 10000
size = 0

for i in range(h):
    for j in range(w):
        pt1 = [j, i]
        owner = '.'
        sDist = 999999
        formerBestDist = 0
        
        totalDist = 0
        for k in range(len(points)):
            dist = manhattanDist(pt1, points[k])
            totalDist += dist
            if dist <= sDist:
                formerBestDist = sDist
                sDist = dist
                owner = k
        if formerBestDist == sDist:
            owner = '.'
        if(totalDist < 10000):
            size += 1
        if owner not in infTerritories:
            if i == 0 or j == 0 or i == h-1 or j == w-1:
                infTerritories.add(owner)
            elif owner in territories:
                territories[owner] += 1
            else:
                territories[owner] = 1
        grid[i, j] = owner

max = -1
for key in territories:
    if territories[key] > max:
        max = territories[key]
print(max)
print(size)