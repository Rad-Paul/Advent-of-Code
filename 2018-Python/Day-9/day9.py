from collections import defaultdict

class Node:
    def __init__(self, data):
        self.data = data
        self.next = None
        self.prev = None
    def view(start):
        toR = ''
        toR += str(start.data) + ' '
        current = start
        while current.next != start:
            toR += str(current.next.data) + ' '
            current = current.next
        print(toR) 

def addMarble(node, value):
    current = node.next
    new = Node(value)
    new.prev = current
    new.next = current.next
    current.next.prev = new
    current.next = new
    return new

def removeMarble(node):
    for i in range(7):
        node = node.prev
    node.prev.next = node.next
    node.next.prev = node.prev
    score = node.data
    node = node.next
    return node, score

playerCount = 493
#multiplied my 100 for part 2
lastMarble = 100 * 71863

start = Node(0)
start.next = start
start.prev = start

players = defaultdict(int)

current = start
playerInd = 1
for i in range(1, lastMarble+1):
    playerInd = (playerInd - 1) % playerCount + 1
    if i % 23 == 0:
        new, score = removeMarble(current)
        players[playerInd] += i + score
    else:
        new = addMarble(current, i)
    current = new    
    playerInd += 1

print(max(players.values()))