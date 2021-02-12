$('.card-title').click(function() {
    if(!$('#criteria-collapser').hasClass("collapsed")){
        $('.arrow-down').animate(
            { deg: -90 },
            {
              duration: 300,
              step: function(now) {
                $(this).css({ transform: 'rotate(' + now + 'deg)' });
              }
            }
        );
    }else{
        $('.arrow-down').animate(
            { deg: 0 },
            {
              duration: 300,
              step: function(now) {
                $(this).css({ transform: 'rotate(' + now + 'deg)' });
              }
            }
        );
    }
});