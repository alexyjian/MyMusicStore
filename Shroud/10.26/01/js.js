//W:87,A:65,S:83,D:68

window.onload = function () {
    var player = document.getElementById('bal');
    var move = 11;
    var toppos=player.offsetTop;
    var leftpos=player.offsetLeft;
    var b=1,t=1,l=1,r=1;
    
    document.onkeydown = function (event) {
        event = event ? event : window.event;
        
        if (event.keyCode == "87") {   
            b+=5;      
            player.style.bottom=i+'px';
        }else if(event.keyCode == "65"){
            r+=5;      
            player.style.right=i+'px';
            player.style.left='';
        }else if(event.keyCode == "83"){
            t+=5;      
            player.style.top=i+'px';
        }else if(event.keyCode == "68"){
            l+=5;      
            player.style.left=i+'px';
        }

    }
    
}