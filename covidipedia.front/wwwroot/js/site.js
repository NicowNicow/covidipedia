function graphScroll(graph){
    elmnt = document.getElementById("group"+graph);
    elmnt.scrollIntoView({behavior: "smooth"})
}

document.getElementById("searchbar").addEventListener('keydown', replaceGraph);

function replaceGraph(event){
    if(event.keyCode === 13){
        $("#low-header button").hide();
        $("#low-header table").show();

    }
}

var trigger = document.querySelector('#datePicker');
var dateComponent = new DatePicker({
    el: document.querySelector('#calendar'),
    trigger: trigger,
    onchange: function (curr) {
        trigger.value = curr;
    }
});

trigger.onfocus = function () {
    dateComponent.show();
};