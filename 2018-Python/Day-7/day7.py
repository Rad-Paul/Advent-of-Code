from collections import defaultdict

def part2(prereq):
    available = []
    res = ''
    workers = defaultdict(lambda: defaultdict(int))
    for i in range(1,6):
        workers[i]
    for entry in prereq:
        if len(prereq[entry] == 0):
            available.append(entry)
    
    while True:
        available.sort(reverse=True)
        while len(available) > 0:   
            step = available.pop()
            for w in workers:           
                if(len(workers[w]) == 0):
                    workers[w][step] = ord(step) - ord('A') + 1
                    break
        


with open('input.txt', 'r') as file:
    content = file.read().split('\n')

unavailable = defaultdict(lambda: set())
prereq = defaultdict(lambda: set())
available = []
for line in content:
    split = line.split(' must be finished before step ')
    req = split[0][-1]
    res = split[1][0]
    if res in available:
        available.remove(res)
    unavailable[res].add(req)
    prereq[res].add(req)
    if req not in unavailable:
        if req not in available:            
            available.append(req)

order = ''
while len(available) > 0:
    available.sort(reverse=True)
    done = available.pop()
    order += done
    for step in unavailable:
        if done in unavailable[step]:
            unavailable[step].remove(done)
            if(len(unavailable[step]) == 0):
                available.append(step)

print(order)