content = ""

with open('input.txt', 'r') as file:
    content = file.read()

input = content.split('\n')
sum = 0

frequencies = set()
valueFound = False

index = 0

while valueFound == False:
    for element in input:
        sum += int(element)
        index += 1
        if(sum in frequencies):
            print(sum)
            valueFound = True
            break
        frequencies.add(sum)
    

print(index)
print(sum)