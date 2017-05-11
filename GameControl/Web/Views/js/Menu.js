$(document).ready(function() {

  var active1 = false;
  var active2 = false;
  var active3 = false;
  var active4 = false;

    $('.home').on('mousedown touchstart', function() {
    
        if (!active1) 
            $(this).find('.player').css({'background-color': 'gray', 'transform': 'translate(0px,125px)'});
        else
            $(this).find('.player').css({'background-color': 'dimGray', 'transform': 'none'});
                    
        if (!active2) 
            $(this).find('.team').css({'background-color': 'gray', 'transform': 'translate(60px,105px)'});
        else 
            $(this).find('.team').css({'background-color': 'darkGray', 'transform': 'none'});
            
        if (!active3) 
            $(this).find('.tournament').css({'background-color': 'gray', 'transform': 'translate(105px,60px)'});
        else 
            $(this).find('.tournament').css({'background-color': 'silver', 'transform': 'none'});
        
        if (!active4) 
            $(this).find('.match').css({'background-color': 'gray', 'transform': 'translate(125px,0px)'});
        else 
            $(this).find('.match').css({'background-color': 'silver', 'transform': 'none'});
        
        active1 = !active1;
        active2 = !active2;
        active3 = !active3;
        active4 = !active4;
      
    });
});