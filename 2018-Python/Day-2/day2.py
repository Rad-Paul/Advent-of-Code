def part2(ids):
    allStringLengths = len(ids[0])
    for id in ids:
        for otherId in ids:     
            #save the indexes since we know we can find the answer by finding the two strings that have only one differing character
            #remove the character from the strings via the one index in the set and we get the final answer       
            differingCharIndexes = set()

            for ind in range(allStringLengths):

                if(id[ind] != otherId[ind]):
                    differingCharIndexes.add(ind)

            if len(differingCharIndexes) == 1:
                toReturn = ''
                differingIndex = int(differingCharIndexes.pop())
                print(id, otherId)
                
                for i in range(allStringLengths):
                    if i != differingIndex:
                        toReturn += id[i]
                return toReturn
    
    return 'failed'            

with open('input.txt', 'r') as file:
    content = file.read()

ids = content.split('\n')

#part 1
repeatOfTwo = 0
repeatOfThree = 0

for id in ids:
    chars = {}
    twoRepeats = set()
    threeRepeats = set()
    for c in id:
        if c not in chars:
            chars[c] = 1
        elif c in chars:
            chars[c] += 1
            if chars[c] == 2:
                twoRepeats.add(c)
            elif chars[c] == 3:
                threeRepeats.add(c)
                twoRepeats.remove(c)
            #not necessary for the right answer, but based on input this makes sure you always get the right answer
            #elif chars[c] == 4:
            #   threeRepeats.remove(c)
    if len(twoRepeats) > 0:
        repeatOfTwo += 1
    if len(threeRepeats) > 0:
        repeatOfThree += 1          

print(repeatOfTwo * repeatOfThree)  
print(part2(ids))