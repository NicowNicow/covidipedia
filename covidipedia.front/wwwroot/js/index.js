$('.card-title').click(function() {
  if(!$("*").hasClass("collapsed")){
      $(this).children().animate(
          { deg: -90 },
          {
            duration: 300,
            step: function(now) {
              $(this).css({ transform: 'rotate(' + now + 'deg)' });
            }
          }
      );
  }
  if($("*").hasClass("collapsed")){
      $(this).children().animate(
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