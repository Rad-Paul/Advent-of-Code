def Part1(opcode):
    index = 0

    #position 1 is replaced with 12 and position 2 is replaced with 2
    opcode[1] = 12
    opcode[2] = 2
    while True:
        print(opcode[index])
        if index >= len(opcode):
            break
        elif int(opcode[index]) == 1:
            opcode[int(opcode[index + 3])] = int(opcode[int(opcode[index + 1])]) + int(opcode[int(opcode[index + 2])])
            index +=4
        elif int(opcode[index]) == 2:
            opcode[int(opcode[index + 3])] = int(opcode[int(opcode[index + 1])]) * int(opcode[int(opcode[index + 2])])
            index +=4
        elif int(opcode[index]) == 99:
            break

    print(opcode)
    print(opcode[0])
    return 0

with open('input.txt', 'r') as file:
    content = file.read()

opcode = content.split(',')

Part1(opcode)