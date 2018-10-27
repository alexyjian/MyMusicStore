    function dianwo() {
                var obj = document.getElementById('mydiv');
                var x = obj.offsetLeft
                var y = obj.offsetTop;
                x += 10;
                y += 10;
                obj.style.left = x;
                obj.style.top = y;
                
            }
         function show()
         {
            setInterval('dianwo()',500);
         }
