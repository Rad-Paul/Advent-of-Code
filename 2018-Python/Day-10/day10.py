import numpy as np
with open('input.txt', 'r') as file:
    content = file.read().split('\n')

def showGrid(boundaries, pts):
    minx = boundaries[0]
    maxx = boundaries[1]
    miny = boundaries[2]
    maxy = boundaries[3]

    if((maxx - minx <= 100) and (maxy - miny <= 100)):
        limitx = maxx - minx + 1
        limity = maxy - miny + 1
        grid = [['.' for _ in range(limitx)] for _ in range(limity)]
        
        for pt in pts:
            x = pt[0] - minx
            y = pt[1] - miny
            grid[y][x] = '#'
        for line in grid:
            print(line)
        print()

pos = []
vel = []
for line in content:
    pandv = line.split('> ')
    p = pandv[0].split('=')[1][1:]
    p = list(map(int, p.split(',')))
    v = pandv[1].split('=')[1][1:-1]
    v = list(map(int, v.split(',')))
    pos.append(p)
    vel.append(v)

for i in range(15000):
    minx, miny, maxx, maxy = 99999, 99999, -99999, -99999
    show = True
    for j in range(len(pos)):
        pos[j][0] += vel[j][0]
        pos[j][1] += vel[j][1]
        if(pos[j][0] < minx):
            minx = pos[j][0]
        if(pos[j][0] > maxx):
            maxx = pos[j][0]
        if(pos[j][1] < miny):
            miny = pos[j][1]
        if(pos[j][1] > maxy):
            maxy = pos[j][1]
    if(minx < 0 or miny < 0):
        show = False
    if show:
        print(i+1)
        showGrid([minx, maxx, miny, maxy], pos)
