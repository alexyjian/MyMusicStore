window.onload=function(){
    document.body.onkeydown=function(evt){
        var e=evt?evt:window.event;
        if(e==37)
        
        document.getElementById('img').style.left+='60px';
    }
}