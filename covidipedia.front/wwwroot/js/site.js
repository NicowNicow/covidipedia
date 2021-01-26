function graphScroll(graph){
    elmnt = document.getElementById("group"+graph);
    elmnt.scrollIntoView({behavior: "smooth"})
}

document.getElementById("searchbar").addEventListener('keydown', replaceGraph);

function replaceGraph(event){
    if(event.keyCode === 13){
        $("#low-header button").hide();
        $("#low-header table").show();
        $("#low-header img").show();
    }
}
