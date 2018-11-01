window.onload=function(){
        ul=document.getElementById('ul'),
        ol=document.getElementById('ol').getElementsByTagName('li'),
        index=0,
        timer=null;

 
      // 定义并调用自动播放函数
      if(timer){
          
          clearInterval(timer);
          timer=null;
      }
timer=setInterval(autoplay,2000);
      // 定义图片切换函数
      function autoplay(){
          index++;
          if(index>=ol.length){
              index=0;
          }
         changeoptions(index);   
      }

    //鼠标移到图片时暂停
      slider.onmouseover = function(){
            clearInterval(timer);
        }
    //鼠标离开时继续切换下一张
        slider.onmouseout = function(){
            timer = setInterval(autoplay,2000);
        }
     
     // 遍历所有数字导航实现划过切换至对应的图片
	 for(var i=0;i<ol.length;i++){
		 ol[i].id=i;
		 ol[i].onmouseover=function(){
			 clearInterval(timer);
			 changeoptions(this.id);
			 
             }
         }
         
		function changeoptions(curindex){
			for(var j=0;j<ol.length;j++){
              ol[j].className='';
              ul.style.top=0;    
          }
    
          ol[curindex].className='active';
          ul.style.top=-curindex*200+'px';
          index=curindex;
  //自动切换和点击切换
          if(timer){
            clearInterval(timer);
            timer=null;
        }
  timer=setInterval(autoplay,2000);
            }   
   }
   