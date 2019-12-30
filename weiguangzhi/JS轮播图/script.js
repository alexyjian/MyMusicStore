window.onload=function(){
    var xm_pic=document.getElementById('pic');
    var current_index=0;
    var top=xm_pic.offsetTop;
    var step=20;
    // 启动定时器
    var timer=setTimeout(autuCheck,100);

    function autuCheck(){
        ++current_index;
        
         for(var i=0;i<1000;i++)
        {
               xm_pic.style.top=top-step+'px';            
        }
    }
}