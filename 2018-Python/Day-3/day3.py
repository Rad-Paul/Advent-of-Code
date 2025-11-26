import numpy as np

class Rectangle:
    def __init__(self, id, x, y, w, h):
        self.id = id
        self.x = x
        self.y = y
        self.w = w
        self.h = h
    def inspect(self):
        print(f'id:{self.id}, x:{self.x}, y:{self.y}, w:{self.w}, h:{self.h}')

def getRectangleInstructions(input):
    toR = []
    lines = input.split('\n')
    for line in lines:
        id, x, y, w, h = '', 0, 0, 0, 0

        idAndDimensions = line.split(' @ ')
        id = idAndDimensions[0]

        xyWidthAndHeight = idAndDimensions[1].split(': ')
        xy = xyWidthAndHeight[0].split(',')
        widthAndHeight = xyWidthAndHeight[1].split('x')

        x = int(xy[0])
        y = int(xy[1])
        w = int(widthAndHeight[0])
        h = int(widthAndHeight[1])
        toR.append(Rectangle(id, x, y, w, h))

    return toR
def part1(rectangles):
    w = 1000
    h = 1000
    grid = np.zeros((h, w), dtype=int)
    for rectangle in rectangles:
        for i in range(rectangle.y, rectangle.h + rectangle.y):
            for j in range(rectangle.x, rectangle.w + rectangle.x):
                grid[i][j] += 1
    
    toR = 0
    for i in range(h):
        for j in range(w):
            if(grid[i][j] > 1):
                toR += 1

    print(toR)
def part2(rectangles):
    w = 1000
    h = 1000
    grid = np.zeros((h, w), dtype=int)
    for rectangle in rectangles:
        id = int(rectangle.id[1:])
        for i in range(rectangle.y, rectangle.h + rectangle.y):
            for j in range(rectangle.x, rectangle.w + rectangle.x):
                grid[i][j] += id
    
    answers = []
    for rectangle in rectangles:
        validAnswer = True
        id = int(rectangle.id[1:])
        for i in range(rectangle.y, rectangle.h + rectangle.y):
            for j in range(rectangle.x, rectangle.w + rectangle.x):
                if grid[i][j] != id:
                    validAnswer = False
        if validAnswer == True:
            answers.append(rectangle)

    print(answers[0].id)

with open('input.txt', 'r') as file:
    content = file.read()

rectangles = getRectangleInstructions(content)
part2(rectangles)