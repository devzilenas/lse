var interval;
var timer;
var display

function startTimer()
{    
    interval = setInterval(function ()
    { 
        display.html(timer--);
    }
    , 1000);

    if (timer < 0)
    {
        display.html("redirecting");
        clearInterval(interval);
    }
}

$(document).ready(jQuery(function ($)
{
    timer = 5;
    display = $('#timer');
    startTimer();
}));
