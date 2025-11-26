const fs = require('fs');

let input = fs.readFileSync('input.txt', 'utf-8').split('\r\n');

PartOneAndTwo(input);

function PartOneAndTwo(input){

    let syntaxErrValue = 0;
    let completionCosts = [];

    for(let i = 0; i < input.length; i++){
        let stack = [];
        let row = input[i];
        let corrupt = false;
        for(let j = 0; j < input[i].length; j++){
            let c = row[j];
            if(c == '(' || c == '[' || c == '{' || c == '<'){
                stack.push(c);
            }
            else{
                if(c == ')'){
                    if(top(stack) != '('){
                        corrupt = true;
                        syntaxErrValue += 3;
                        break;
                    }else{
                        stack.pop();
                    }
                }
                else if(c == ']'){
                    if(top(stack) != '['){
                        corrupt = true;
                        syntaxErrValue += 57;
                        break;
                    }else{
                        stack.pop();
                    }
                }
                else if(c == '}'){
                    if(top(stack) != '{'){
                        corrupt = true;
                        syntaxErrValue += 1197;
                        break;
                    }else{
                        stack.pop();
                    }
                }
                else if(c == '>'){
                    if(top(stack) != '<'){
                        corrupt = true;
                        syntaxErrValue += 25137;
                        break;
                    }else{
                        stack.pop();
                    }
                }
            }
        }
        if(!corrupt){
            //incomplete lines must get repaired for part 2
            completionCosts.push(Part2(stack));
        }
    }

    console.log(syntaxErrValue);
    completionCosts.sort((a,b) => a - b);
    console.log(completionCosts);
    console.log(completionCosts[Math.trunc(completionCosts.length/2)]);
}
function Part2(stack){
    //only processing incomplete lines that we got from part1
    let score = 0;

    while(stack.length != 0){
        score *= 5;
        char = stack.pop();
        if(char == '('){
            score += 1;
        }
        else if(char == '['){
            score += 2;
        }
        else if(char == '{'){
            score += 3;
        }
        else if(char == '<'){
            score += 4;
        }
    }

    return score;
}
function top(array){
    return array[array.length-1];
}