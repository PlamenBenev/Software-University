const gameStart = document.querySelector('.game-start');
const gameArea = document.querySelector('.game-area');
const gameOver = document.querySelector('.game-over');
const gameScore = document.querySelector('.game-score');
const gamePoints = gameScore.querySelector('.points')

gameStart.addEventListener('click', () => {
    gameStart.classList.add('hide');

    const wizard = document.createElement('div');
    wizard.classList.add('wizard');
    wizard.style.top = player.y + 'px';
    wizard.style.left = player.x + 'px';
    gameArea.appendChild(wizard);

    player.width = wizard.offsetWidth;
    player.height = wizard.offsetHeight;

    window.requestAnimationFrame(gameAction);
})

let keys = {};
let player = {
    x: 150,
    y: 100,
    height: 0,
    width: 0,
    lastTimeFired: 0
};
let game = {
    speed: 2,
    movingMultiplier: 4,
    fireBallMultiplier: 5,
    fireInterval: 1000,
    cloudSpawned: 3000,
    bugSpawnInterval: 1000
};
let scene = {
    score: 0,
    lastCloudSpawn: 0,
    lastBugSpawn: 0
}

document.addEventListener('keydown',(e)=>{
    keys[e.code] = true;
})
document.addEventListener('keyup',(e)=>{
    keys[e.code] = false;
})

function gameAction(timestamp){
    const wizard = document.querySelector('.wizard');

    let isInAir = (player.y + player.height) <= gameArea.offsetHeight;
    if (isInAir){
        player.y += game.speed;
    }
    if (keys.ArrowDown && isInAir){
        player.y += game.speed * game.movingMultiplier;
    }

    if (keys.ArrowUp && player.y > 0){
        player.y -= game.speed * game.movingMultiplier;
    }
    if (keys.ArrowDown && player.y + player.height < gameArea.offsetHeight){
        player.y += game.speed * game.movingMultiplier;
    }
    if (keys.ArrowLeft && player.x > 0){
        player.x -= game.speed * game.movingMultiplier;
    }
    if (keys.ArrowRight && player.x + player.width < gameArea.offsetWidth){
        player.x += game.speed * game.movingMultiplier;
    }

    wizard.style.top = player.y + 'px';
    wizard.style.left = player.x + 'px';

    scene.score++;
    gamePoints.textContent = scene.score;
    
    let clouds = document.querySelectorAll('.cloud');
    clouds.forEach(cloud => {
        cloud.x -= game.speed;
        cloud.style.left = cloud.x + 'px';
        
        if (cloud.x + clouds.offsetWidth <= 0){
            cloud.parentElement.removeChild(cloud);
        }
    });
    
    // add clouds
    if (timestamp - scene.lastCloudSpawn > game.cloudSpawned + 20000 * Math.random()){
        let cloud = document.createElement('div');
        cloud.classList.add('cloud');
        cloud.x = gameArea.offsetWidth - 200;
        cloud.style.left = cloud.x + 'px';
        cloud.style.top = (gameArea.offsetHeight - 200) * Math.random() + 'px';
        gameArea.appendChild(cloud);
        scene.lastCloudSpawn = timestamp;
        gameArea.appendChild(cloud);
    }
    
    // add bugs
    if (timestamp - scene.lastBugSpawn > game.bugSpawnInterval + 5000 * Math.random()){
        let bug = document.createElement('div');
        bug.classList.add('bug');
        bug.x = gameArea.offsetWidth - 60;
        bug.style.left = bug.x + 'px';
        bug.style.top = (gameArea.offsetHeight - 60) * Math.random() + 'px';
        gameArea.appendChild(bug);
        scene.lastBugSpawn = timestamp;
    }

    let bugs = document.querySelectorAll('.bug');
    bugs.forEach(bug => {
        bug.x -= game.speed * 3;
        bug.style.left = bug.x + 'px';
        if (bug.x + bugs.offsetWidth <= 0){
            bug.parentElement.removeChild(bug);
        }
    });
    
    if (keys.Space && timestamp - player.lastTimeFired > game.fireInterval){
        wizard.classList.add('wizard-fire');
        addFireBall(player);
        player.lastTimeFired = timestamp;
    } else {
        wizard.classList.remove('wizard-fire');
    }

    let fireBalls = document.querySelectorAll('.fire-ball');
    fireBalls.forEach(ball => {
        ball.x += game.speed * game.fireBallMultiplier;
        ball.style.left = ball.x + 'px';

        if (ball.x + ball.offsetWidth > gameArea.offsetWidth){
            ball.parentElement.removeChild(ball);
        }
    })

    window.requestAnimationFrame(gameAction);
}

function addFireBall(){
    let fireBall = document.createElement('div');
    fireBall.classList.add('fire-ball')
    fireBall.style.top = (player.y + player.height / 3 - 5) + 'px';
    fireBall.x = player.x + player.width;
    fireBall.style.left = fireBall.x + 'px';
    gameArea.appendChild(fireBall);
}