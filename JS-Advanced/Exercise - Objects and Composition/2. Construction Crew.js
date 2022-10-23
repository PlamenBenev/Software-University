function food(input) {
    const result = {};
    result.weight = input.weight;
    result.experience = input.experience;
    result.levelOfHydrated = input.levelOfHydrated;
    result.dizziness = input.dizziness;

    if (result.dizziness == true){
        result.levelOfHydrated += result.weight * 0.1 * result.experience;
        result.dizziness = false;
    }

    return result;
}

    console.log(food({ weight: 80,
    experience: 1,  
    levelOfHydrated: 0,  
    dizziness: true }));
    
    console.log(food({ weight: 95,

        experience: 3,
        
        levelOfHydrated: 0,
        
        dizziness: false }));