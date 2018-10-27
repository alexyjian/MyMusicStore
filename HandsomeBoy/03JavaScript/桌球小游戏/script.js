window.onload = function(){
    document.body.onkeydown = function(evt){
        var e = evt ? evt : window.event;
      switch (e.keyCode) {
         //  上
          case 87:
          
          document.getElementById('img').style.top="10px";
              break;
             //  左
              case 65:
          
              document.getElementById('img').style.left="10px";
              break;
             //  下
              case 83:
           
              document.getElementById('img').style.bottom="10px";
              break;
             //  右
              case 68:
             
              document.getElementById('img').style.right="10px";
              break;
            
      }
    }
}