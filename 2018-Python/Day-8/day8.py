def exploreTree(data, ind, total):
    children = data[ind[0]]
    metas = data[ind[0]+1]
    ind[0] += 2
    while(children > 0):
        total += exploreTree(data, ind, 0)
        children -= 1
    for i in range(metas):
        total += data[ind[0]]
        ind[0] += 1
    
    return total

def exploreTree2(data, ind, total):
    children = data[ind[0]]
    metas = data[ind[0]+1]
    ind[0] += 2

    childValues = {}
    for i in range(1, children+1):
        childValues[i] = 0
    for i in range(1, children+1):
        childValues[i] = exploreTree2(data, ind, 0)
        print(childValues)
    for i in range(metas):
        indOfC = data[ind[0]]
        if children == 0:
            total += indOfC
        elif indOfC in childValues:
            total += childValues[indOfC]
        ind[0] += 1
    return total

with open('input.txt', 'r') as file:
    content = file.read()
data = list(map(int, content.split()))
print(exploreTree(data, [0], 0))
print(exploreTree2(data, [0], 0))