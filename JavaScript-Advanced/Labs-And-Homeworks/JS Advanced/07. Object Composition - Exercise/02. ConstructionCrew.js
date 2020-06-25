function modifyWorker(workerObj) {
    const isDizzy = workerObj.dizziness;
    
    if (isDizzy) {
        const levelOfHydration = Number(workerObj.experience) * Number(workerObj.weight) * 0.1;
        workerObj.levelOfHydrated += levelOfHydration;
        workerObj.dizziness = false;
    }

    return workerObj;
}

console.log(modifyWorker({ weight: 80, experience: 1, levelOfHydrated: 0, dizziness: true }));
console.log(modifyWorker({ weight: 120, experience: 20, levelOfHydrated: 200, dizziness: true }));
console.log(modifyWorker({ weight: 95, experience: 3, levelOfHydrated: 0, dizziness: false }));