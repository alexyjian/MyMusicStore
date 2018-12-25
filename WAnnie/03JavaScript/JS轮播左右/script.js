function $(id){
    return document.getElementById(id);
}

window.onload = function (){
    var target = 0;
    var leader = 0;

    //鼠标悬停时箭头出现
    $("box").onmousemove = function(){
        $("arrow").style.display = "block";
    }
    $("box").onmouseout = function(){
        $("arrow").style.display = "none";
    }

    //点两只左箭头，left +350  right -350
    $("left").onclick = function (){
        target += 350;
        console.log(target+ "l");
    }
    $("right").onclick = function (){
        target -= 350;
        console.log(target+ "r");
    }

    //动画  把ul的left属性设置为对应的值
    setInterval(function(){
        if (target >= 0){
            target = 0;
        }
        else if (target <= -1400){
            target = -1400;
        }

        leader = leader + (target - leader) / 10;
        $("ad_img").style.left = leader + "px";

    },30);
}