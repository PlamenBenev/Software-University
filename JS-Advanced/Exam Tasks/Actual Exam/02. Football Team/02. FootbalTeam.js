class FootballTeam {
    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions(footballPlayers) {
        let names = [];
        footballPlayers.forEach(p => {
            let [name, age, playerValue] = p.split('/');
            let thePlayer = this.invitedPlayers.find(x => x.name == name);

            if (thePlayer == undefined) {
                this.invitedPlayers.push({
                    name: name,
                    age: Number(age),
                    playerValue: Number(playerValue)
                });
            } else {
                if (thePlayer.playerValue < Number(playerValue)) {
                    thePlayer.playerValue = Number(playerValue);
                }
            }
            if (!names.includes(name)) {
                names.push(name);
            }
        });
        return `You successfully invite ${names.join(', ')}.`;
    }

    signContract(selectedPlayer){
        let [name,playerOffer] = selectedPlayer.split('/');
        
        let thePlayer = this.invitedPlayers.find(x => x.name == name);

        if (thePlayer == undefined){
            throw new Error(`${name} is not invited to the selection list!`);
        }
        if (thePlayer.playerValue > Number(playerOffer)){
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${thePlayer.playerValue - Number(playerOffer)} million more are needed to sign the contract!`);
        }

        thePlayer.playerValue = 'Bought';
        return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`;
    }
    ageLimit(name, age){
        let thePlayer = this.invitedPlayers.find(x => x.name == name);

        if (thePlayer == undefined){
            throw new Error(`${name} is not invited to the selection list!`);
        }
        if (thePlayer.age < age){
            if (age - thePlayer.age < 5){
                return `${name} will sign a contract for ${age - thePlayer.age} years with ${this.clubName} in ${this.country}!`;
            } else {
                return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
            }
        } else {
            return `${name} is above age limit!`
        }
    }
    transferWindowResult(){
        let result = 'Players list:\n';
        let arr = [];

        this.invitedPlayers.sort((a,b)=> a.name.localeCompare(b.name))
        this.invitedPlayers.forEach(x =>{
            arr.push(`Player ${x.name}-${x.playerValue}`)
        })
        result += arr.join('\n');
        return result;
    }
}