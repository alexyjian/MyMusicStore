
    var left =document.getElementById('left');
    var right =document.getElementById('right');
    var scroll = document.getElementById('scroll'); 

    var timer = null;
    var leader = 0;
    var target = 0;
    var i=0;
    var ul =scroll.children[0];

    right.onclick =function(){
        i++;
        if(i>=0){
            target =-300*i+'px';
        }
        if(i<0){
            target =i* 300+300+'px';
        }
        if(i>=4){
            i=0;
            target=0+'px';
        }
        ul.style.left = target ;
        console.log(i);
        console.log(target);
    }
    left.onclick =function(){
        i--;
        if(i<=0){
            target =i* 300+'px';
        }
        if(i>0){
            target =-i* 300+300+'px';
        }
        if (i<=-4){
            i=0;
            target=-900+'px';
        }
        ul.style.left = target ;
        console.log(i);
        console.log(target);
    }
   
