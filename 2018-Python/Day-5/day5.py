import numpy as np

def peek(stack):
    if(len(stack) > 0):
        return stack[-1]
    return '0'

def part2(content):
    shortestLength = len(content)
    for i in range(ord('A'), ord('Z')+1):
        stack = []
        for c in content:
            lastC = peek(stack)
            if ord(c) == i or ord(c) == i + 32:
                continue
            elif np.abs(ord(c) - ord(lastC)) == 32:
                stack.pop()
            else:
                stack.append(c)
        if len(stack) < shortestLength:
            shortestLength = len(stack)
    print(shortestLength)

with open('input.txt', 'r') as file:
    content = file.read()
stack = []
for c in content:
    lastC = peek(stack)
    if np.abs(ord(c) - ord(lastC)) == 32:
        stack.pop()
    else:
        stack.append(c)

part2(content)