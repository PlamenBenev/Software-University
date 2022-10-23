function attachEventsListeners() {
    let getDays = document.getElementById('days');
    let gethours = document.getElementById('hours');
    let getminutes = document.getElementById('minutes');
    let getseconds = document.getElementById('seconds');

    
    document.querySelector('main').addEventListener('click', (e) => {
        if (e.target.id == 'daysBtn'){
            gethours.value = Number(getDays.value) * 24 ; 
            getminutes.value = Number(gethours.value) * 60 ;
            getseconds.value = Number(getminutes.value) * 60 ;
        }
        if (e.target.id == 'hoursBtn'){
            getDays.value = Math.floor(Number(gethours.value) / 24 ); 
            getminutes.value = Number(gethours.value) * 60 ;
            getseconds.value = Number(getminutes.value) * 60 ;
        }
        if (e.target.id == 'minutesBtn'){
            gethours.value = Math.floor(Number(getminutes.value) / 60) ;
            getDays.value = Math.floor(Number(gethours.value) / 24 ); 
            getseconds.value = Number(getminutes.value) * 60 ; 
        }
        if (e.target.id == 'secondsBtn'){
            getminutes.value = Math.floor(Number(getseconds.value) / 60) ;
            gethours.value = Math.floor(Number(getminutes.value) / 60) ;
            getDays.value = Math.floor(Number(gethours.value) / 24 ); 
        }
    });
}