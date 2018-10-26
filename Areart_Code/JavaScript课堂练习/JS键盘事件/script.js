

window.onload = function () {
    document.body.onkeydown = function (evt) {
        var e = evt ? evt : window.event;
        var c = 10;
        //left  
        if (e.keCode == 37) {
            document.getElementById('img').style.paddingLeft = c + 'px';
            alert('2222');
        }
        //top  
        if (e.keCode == 38) {

        }
        //right 
        if (e.keCode == 39) {

        }
        //botom 
        if (e.keCode == 40) {

        }
    }
}










