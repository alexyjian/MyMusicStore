//页面加载完成时
window.onload=function(){
    var ul=document.getElementById('head_ul');
    var head_left=document.getElementById('head_left');
    var head_right=document.getElementById('head_right');
    //取所有子元素
    var ullis=ul.children;
    //用来控制left
    var leader=0;
    var target=0;
    //计算自动轮播页数
    var intr=0;
    //左方向过度
    head_right.onclick=function(){
       intr++;         
       if(intr==(ullis.length)-1){
           intr=0;
       }
       target=-intr*576;//目标位置=当前index索引号*图片宽度
    }
    //右方向过度
    head_left.onclick=function(){
        intr--;          
        if(intr<=0){
            intr=0;
        }
        target=-intr*576;//目标位置=当前index索引号*图片宽度
     }
     //鼠标悬停
     document.getElementById('head').onmouseover=function(){
         head_left.style.display='block';
         head_right.style.display='block';
     }
     document.getElementById('head').onmouseout=function(){
        head_left.style.display='none';
        head_right.style.display='none';
    }
    //过度动画
    setInterval(function(){
        leader=leader+(target-leader)/100;
        ul.style.left=leader+'px';
    },2)
}