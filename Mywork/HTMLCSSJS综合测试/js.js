window.onload = function () {

    var ul = document.getElementById("ad_ul");
    var ol = document.getElementById("ad_ol");
    var ollis = ol.children;
    var leader = 0;
    var target = 0;

    var current_index=0;
    var timer=null;

    timer =this.setInterval(autoPlay,1500);

    for (var i = 0; i < ollis.length; i++) {
        ollis[i].index = i;
        ollis[i].onmouseover = function () {
            for (var j = 0; j < ollis.length; j++) {
                ollis[j].className = "";  
            }
            this.className = "current";
            target = -this.index * 490;  
        }

    } 

    ul.onmouseover=function(){
        clearInterval(timer);
    }

    ul.onmouseout=function(){
        timer=setInterval(autoPlay,1500);
    }

    
    setInterval(function () {
        
        leader = leader + (target - leader) / 10;
        ul.style.left = leader + 'px';
    }, 20)

    function autoPlay() {
        if(current_index == 4) {
            current_index = -1;
        }
        current_index++;
        for (var i = 0; i < nums.length; i++) {
            nums[i].className = "";
        }
        nums[current_index].className = "current";
        target = -current_index * 555;
    }

}