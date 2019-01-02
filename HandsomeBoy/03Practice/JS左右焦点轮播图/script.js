
   function $(id) {
       return document.getElementById(id);
   }
   window.onload = function () {
   
    var leader = 0;
    var target = 0;

    //鼠标悬停箭头出现
    $('box').onmouseover = function(){
        $("arrow").style.display = "block";
    }
    $('box').onmouseout = function(){
        $("arrow").style.display = "none";
    }
    
    $('left').onclick = function(){
        target += 520;
      
        console.log(leader);
    }
    $('right').onclick = function(){
        target -=  520;
      
        console.log(leader);
    }

    setInterval(function (){
        if (target >= 0) {
            target = 0;
        }
        else if (target <= -2080) {
            target = -2080;
        }
        leader = leader +(target-leader)/10;
        $("ad_ul").style.left = leader + "px";
       
    },30)
}