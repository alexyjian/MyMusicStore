;
// 使用transition
// window.onload=function(){
//     var ulsli=document.getElementById('adul')
//     var ollis=document.getElementById('ol').children;
//     for(let i=0;i<ollis.length;i++){
//         ollis[i].addEventListener('mouseover',function(){
//             ulsli.style.left=-(490*i)+'px';
//             for(let j=0;j<ollis.length;j++)ollis[j].className='';
//             ollis[i].className=' current';
//         }); 
//     }
// }


//使用setInterval
window.onload = function () {
    var ulsli = document.getElementById('adul')
    var ollis = document.getElementById('ol').children;
    var step = 0;
    var timer;
    var index = 0;
    for (let i = 0; i < ollis.length; i++) {
        ollis[i].addEventListener('mouseover', function () {
            for (let j = 0; j < ollis.length; j++)
                ollis[j].className = '';
            ollis[i].className = ' current';
            index = i;
        });

    }
    timer = setInterval(function () {
        if (step > -(index * 490)){
            step-=2;
            ulsli.style.left = step + 'px';
        }else{
            step+=2;
            ulsli.style.left = step + 'px';
        }
        
    }, 1);
}