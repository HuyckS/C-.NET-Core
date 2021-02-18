class SLQNode {
    constructor(val) {
        this.val = val;
        this.next = null;
    }
}

class SLQueue {
    constructor() {
        this.head = this.back = null;
    }

    enqueue(val) {
        const node = new SLQNode(val);

        if (!this.head) {
            this.head = this.back = node;
        } else {
            this.back.next = node;
            this.back = node;
        }
        return this.size();
    }

    dequeue() {
        if (!this.head) return null;
        const { val } = this.head;

        // point front to the next node
        this.head = this.head.next;
        return val;
    }

    size() {
        if (!this.head) return 0;
        let count = 0, runner = this.head;
        while (runner) {
            count++;
            runner = runner.next;
        }
        return count;
    }

    front() {
        return this.head ? this.head.val : null;
    }

    /**
     * Determines whether the queues have the same values in the same order.
     * 
     * Use ONLY the provided queue methods
     * do not manually index the queue items
     * no extra array or objects
     * restore the queues to their original state
     * 
     * @param {SLQueue} otherQueue
     * @returns {boolean}
     */

    compare(otherQueue) {
        // your code here
        // check if size is the same
        // loop and dequeue each check and then enqueue
        if (this.size() !== otherQueue.size()) {
            return false
        }
    }

    /**
     * Determines whether the queue is a palindrome.
     * 
     * use only 1 stack as additional storage (no additional arrays / objects)
     * do not manually index the queue, use the provided queue methods and stack methods
     * restore the queue to original state when done
     * 
     * @returns {boolean}
     */

    isPalindrome() {
        // your code here
    }
}

/**
 * BONUS
 */

class MinStack {
    constructor() {
        // your code here
    }

    push(val) {
        // your code here
    }

    pop() {
        // your code here
    }

    top() {
        // your code here
    }

    /**
     * Returns the minimum value in constant time: O(1)
     */

    min() {
        // your code here
    }
}

const queue = new SLQueue();

queue.enqueue('A');
queue.enqueue('B');
// A - B
queue.enqueue('C');
// A - B - C

const otherQueue = new SLQueue();

otherQueue.enqueue('A');
otherQueue.enqueue('B');
// A - B
otherQueue.enqueue('C');
// A - B - C

console.log(queue.compare(otherQueue)); // should log true
console.log(queue.isPalindrome()); // should log false