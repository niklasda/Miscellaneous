/**
    opera       11.52
    chrome      15.0.874
    firefox     8.0
    ie          9.0.8112
    safari      5.1.1
 */
function draw_load()
{
    var canvas = document.getElementById("board");

    var ctx = canvas.getContext("2d");
    ctx.fillStyle = "rgb(200, 0, 0)";
    ctx.fillRect(10, 10, 100, 100);

    ctx.fillStyle = "rgba(0, 0, 200, 0.5)";
    ctx.lineWidth = 3;
    //cts.strokeStyle="#0f0000";
    ctx.fillRect (30, 30, 55, 50);

    ctx.font = "20px sans-serif";
    ctx.fillText("Dahlex", 35, 35);

    ctx.beginPath();
    ctx.moveTo(30, 30);
    ctx.lineTo(150, 150);
    ctx.bezierCurveTo(60, 70, 60, 70, 70, 150);
    ctx.lineTo(30, 30); 
    ctx.fill();

    canvas.onclick = draw_click;
    canvas.onmousemove = draw_move;

    var body = document.getElementById("body");
    body.onkeydown = draw_key;


}

function logMsg(msg)
{
    var log = document.getElementById("log");
    log.innerHTML = msg;
}

function draw_click(evt)
{
    var canvas = document.getElementById("board");
    logMsg("click x=" + (evt.pageX- canvas.offsetLeft)  + " y=" + (evt.pageY- canvas.offsetTop) );


    if (evt.pageX- canvas.offsetLeft > 300 && evt.pageX- canvas.offsetLeft < 400)
    {
        var granade = document.getElementById("granade");
        granade.play();
    }}

function draw_move(evt)
{
    var canvas = document.getElementById("board");
    logMsg("move x=" + (evt.pageX- canvas.offsetLeft) + " y=" + (evt.pageY- canvas.offsetTop));


    if (evt.pageX- canvas.offsetLeft > 50 && evt.pageX- canvas.offsetLeft < 200)
    {
        var granade = document.getElementById("granade");
        granade.play();
    }
}

function draw_key(evt)
{
    switch (evt.keyCode)
    {
        case 38:  /* Up arrow was pressed */
            var granade = document.getElementById("granade");
            granade.play();
            break;
        case 40:  /* Down arrow was pressed */

            break;
        case 37:  /* Left arrow was pressed */

            break;
        case 39:  /* Right arrow was pressed */

            break;
    }
}

function load_settings()
{
    var store = window.localStorage();
    var playerName = store.getItem("playerName");
}

function save_settings()
{
    var store = window.localStorage();
    store.setItem("playerName", "Niklas");
}
