function badInputCheck(val1, val2)
{ 
    if (val1 != '' && val2 != '') 
    {
        let result = Number(val1)
        let result2 = Number(val2)

        return Number.isNaN(result) || Number.isNaN(result2) ? true:false
    }else
    {
        return true
    }
}
function add(val1,val2) 
{
    return answerString(val1,val2,val1+val2, '+')   
}
function subtract(val1,val2) 
{
    return answerString(val1,val2,val1-val2, '-')
}
function multiply(val1,val2) 
{
    return answerString(val1,val2,val1*val2, '*')
}
function divide(val1,val2) 
{
    return answerString(val1,val2,val1/val2, '/')
}
function answerString(val1,val2,answer,operator) 
{
    return `${val1}${operator}${val2} = ${answer}`
}
function decider(val1,val2,badCheck,button) 
{
    if (!badCheck) 
    {
        let answer
        let a = Number(val1);
        let b = Number(val2);
        switch (button) 
        {
            case 'add':
                answer = add(a,b);
                break;
            case 'sub':
                answer = subtract(a,b);
                break;
            case 'mul':
                answer = multiply(a,b);
                break;
            case 'div':
                answer = divide(a,b);
                break;
        }
        valid(answer)
    }else
    {
        invalid()
    }
}
function valid(a) 
{
    answer.innerHTML = a;
    answer.style.color = 'green';
}
function invalid() 
{
    answer.innerHTML = 'Error';
    answer.style.color = 'red';
}

let btnAdd = document.getElementById('btnadd')
let btnSub = document.getElementById('btnsubtract')
let btnMul = document.getElementById('btnmultiply')
let btnDiv = document.getElementById('btndivide')
let firstNum = document.getElementById('first')
let secondNum = document.getElementById('second')
let answer = document.getElementById('answer')

btnAdd.addEventListener('click',function(){decider(firstNum.value,secondNum.value,badInputCheck(firstNum.value,secondNum.value),'add')})
btnSub.addEventListener('click',function(){decider(firstNum.value,secondNum.value,badInputCheck(firstNum.value,secondNum.value),'sub')})
btnMul.addEventListener('click',function(){decider(firstNum.value,secondNum.value,badInputCheck(firstNum.value,secondNum.value),'mul')})
btnDiv.addEventListener('click',function(){decider(firstNum.value,secondNum.value,badInputCheck(firstNum.value,secondNum.value),'div')})

