from collections import defaultdict

def Part2(gTTables):
    gid, bestMin, highestVal = 0, 0, 0
    for id in gTTables:
        for t in gTTables[id]:
            if gTTables[id][t] > highestVal:
                highestVal = gTTables[id][t]
                bestMin = t
                gid = id
    print(int(gid) * bestMin)

with open('input.txt', 'r') as file :
    content = file.read().split('\n')
content.sort()

gTimeAsleep = defaultdict(int)
gTTables = defaultdict(lambda: defaultdict(int))
gid = 0
for line in content:
    split = line.split()
    if 'falls' in line:
        sTime = int(split[1].split(':')[1][:-1])
    elif 'wakes' in line:
        eTime = int(split[1].split(':')[1][:-1])
        slept = eTime - sTime
        gTimeAsleep[gid] += slept
        for i in range(sTime, eTime):
            gTTables[gid][i] += 1
    else:
        gid = split[3][1:]

max = -99999
cid = 0
for g in gTimeAsleep:
    if gTimeAsleep[g] > max:
        max = gTimeAsleep[g]
        cid = g

bestMin = -999
timesPerMin = 0

for t in gTTables[cid]:
    if gTTables[cid][t] > timesPerMin:
        bestMin = t
        timesPerMin = gTTables[cid][t]

result = int(cid) * bestMin
print(result)

Part2(gTTables)