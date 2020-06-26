function pressHouse() {
     class Article {
         constructor(title, content) {
             this.title = title;
             this.content = content;
         }

         toString() {
             return `Title: ${this.title}\nContent: ${this.content}`;
         }
     }

     class ShortReports extends Article {
         constructor(title, content, originalResearch) {
             if (content.length > 150) {
                throw new Error('Short reports content should be less then 150 symbols.');
             }

             super(title, content);

             if (!originalResearch.title || !originalResearch.author) {
                throw new Error('The original research should have author and title.');
             }

             this.originalResearchTitle = originalResearch.title;
             this.author = originalResearch.author;
             this.comments = [];
         }

         addComment(comment) {
             this.comments.push(comment);
             return 'The comment is added.';
         }

         toString() {
             let outputMessage = '';

             if (this.comments.length !== 0) {
                 outputMessage = `${super.toString()}` + `\nOriginal Research: ${this.originalResearchTitle} by ${this.author}\nComments:`;

                 this.comments.forEach(comment => {
                     outputMessage += `\n${comment}`;
                 })
             }else {
                outputMessage = `${super.toString()}\nOriginal Research: ${this.originalResearchTitle} by ${this.author}`;
             }

             return outputMessage.trimEnd();
         }
     }

     class BookReview extends Article {
         constructor(title, content, book) {
             super(title, content);
             this.name = book.name;  
             this.author = book.author;
             this.clients = [];
         }

         addClient(clientName, orderDescription) {
            if (this.clients.find(x => x.clientName === clientName)) {
                throw new Error("This client has already ordered this review.");
            }

             this.clients.push({clientName, orderDescription});
             return `${clientName} has ordered a review for ${this.name}`;
         }

         toString() {
            let outputMessage = '';

            if (this.clients.length !== 0) {
                outputMessage = `${super.toString()}` + `\nBook: ${this.name}\nOrders:`;

                this.clients.forEach(({clientName, orderDescription}) => {
                    outputMessage += `\n${clientName} - ${orderDescription}`;
                });
            }else {
               outputMessage = `${super.toString()}` + `\nBook: ${this.name}`;
            }

            return outputMessage.trimEnd();
         }
     }

     return {
         Article,
         ShortReports,
         BookReview
     };
}