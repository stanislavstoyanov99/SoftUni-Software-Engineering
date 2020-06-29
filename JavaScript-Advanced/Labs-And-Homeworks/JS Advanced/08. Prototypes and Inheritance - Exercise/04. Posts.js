function posts() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);

            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let output = '';
            output += super.toString();
            output += `\nRating: ${this.likes - this.dislikes}`;

            let commentsCount = this.comments.length;
            if (commentsCount !== 0) {
                output += '\nComments:';

                // Solution with reduce
                output += this.comments.reduce((acc, curr) => {
                    return acc += `\n * ${curr}`
                }, "");

                // Can be done with simple forEach
                // this.comments.forEach(comment => {
                //     output += `\n * ${comment}`;
                // })
            }

            return output.trimEnd();
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);

            this.views = views;
        }

        view() {
            this.views++;
            return this;
        }

        toString() {
            let output = '';
            output += super.toString();

            output += `\nViews: ${this.views}`;
            return output.trimEnd();
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    };
}

let postsInstance = posts();

let post = new postsInstance.Post('Post', 'Content');
console.log(post.toString());

let scm = new postsInstance.SocialMediaPost('TestTitle', 'TestContent', 25, 30);

scm.addComment('Good post');
scm.addComment('Very good post');
scm.addComment('Wow!');

console.log(scm.toString());