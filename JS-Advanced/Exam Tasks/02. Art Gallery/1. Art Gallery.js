class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = { "picture": 200, "photo": 50, "item": 250 };
        this.listOfArticles = [];
        this.guests = [];
    }

    addArticle(articleModel, articleName, quantity) {
        if (this.possibleArticles[articleModel.toLowerCase()] == undefined) {
            throw new Error("This article model is not included in this gallery!");
        }

        let theArticle = this.listOfArticles.find(x => x.articleName == articleName && x.articleModel == articleModel);

        if (theArticle != undefined) {
            theArticle.quantity++;
        } else {
            this.listOfArticles.push({
                articleModel: articleModel.toLowerCase(),
                articleName: articleName,
                quantity: quantity
            });
        }
        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }
    inviteGuest(guestName, personality) {
        let theGuest = this.guests.find(x => x.guestName == guestName);
        if (theGuest != undefined) {
            throw new Error(`${guestName} has already been invited.`);
        } else {
            let points = 50;

            if (personality == 'Middle') {
                points = 250;
            } else if (personality == 'Vip') {
                points = 500;
            }

            this.guests.push({
                guestName: guestName,
                points: points,
                purchaseArticle: 0
            });
            return `You have successfully invited ${guestName}!`;
        }
    }
    buyArticle(articleModel, articleName, guestName) {
        let theArticle = this.listOfArticles.find(x => x.articleModel == articleModel && x.articleName == articleName)
        let theGuest = this.guests.find(x => x.guestName == guestName);
        if (theArticle == undefined){
            throw new Error("This article is not found.");
        }
        if (theArticle.quantity == 0){
            return `The ${articleName} is not available.`;
        }
        if (theGuest == undefined){
            return `This guest is not invited.`;
        }
        if (theGuest.points < this.possibleArticles[theArticle.articleModel]){
            return `You need to more points to purchase the article.`;
        } else {
            theGuest.points -= this.possibleArticles[theArticle.articleModel];
            theArticle.quantity--;
            theGuest.purchaseArticle++;
        }
        return `${guestName} successfully purchased the article worth ${this.possibleArticles[theArticle.articleModel]} points.`;
    }
    showGalleryInfo (criteria){
        if (criteria == 'article'){
            let result = "Articles information:\n";
            let arr = [];
            this.listOfArticles.forEach(x => {
                arr.push(`${x.articleModel} - ${x.articleName} - ${x.quantity}`)
            });
            result += arr.join('\n');
            return result;
        }
        if (criteria == 'guest'){
            let result = "Guests information:\n";
            let arr = [];
            this.guests.forEach(x => {
                arr.push(`${x.guestName} - ${x.purchaseArticle}`)
            });
            result += arr.join('\n');
            return result;
        }
    }
}

const artGallery = new ArtGallery('Curtis Mayfield');
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
artGallery.buyArticle('picture', 'Mona Liza', 'John');
artGallery.buyArticle('item', 'Ancient vase', 'Peter');
console.log(artGallery.showGalleryInfo('article'));
console.log(artGallery.showGalleryInfo('guest'));