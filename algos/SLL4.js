/**
 * Singly-Linked List Node class
 */

class SLLNode {
    constructor(val) {
        this.val = val;
        this.next = null;
    }
}

/**
 * Singly-Linked List class
 */

class SLL {
    constructor() {
        this.head = null; // the list is initially empty
    }

    insertAtBack(val) {
        const node = new SLLNode(val);

        if (!this.head) {
            this.head = node;
        } else {
            let runner = this.head;

            while (runner.next) {
                runner = runner.next;
            }

            runner.next = node;
        }

        return this;
    }

    /**
     * Returns the second to last value.
     * 
     * @returns {any|null} the second-to-last value (or null if empty)
     */

    secondToLast() {
        let runner = this.head;
        if (runner === null || runner.next === null) { //if list is empty to begin with
            return null;
        }
        while (runner != null) {
            console.log("This is the current:", runner.val)
            if (runner.next.next === null) {
                return runner.val;
            }
            runner = runner.next;
        }
    }


    /**
     * Removes the value and returns a confirmation.
     * 
     * @param {any} val
     * @returns {boolean} confirmation of success
     */

    removeVal(val) {
        if (this.head === null) { // if empty -- return false
            return false;
        }
        if (this.head.val === val) { //if the head is our value
            this.head = runner.next; // reassign the head to the next one (even if null)
            return true;
        }
        let runner = this.head; // assign runner to the start
        let prev; // initialize a second runner (previous runner)
        while (runner !== null) { // while current node exists
            if (runner.val == val) { // if it is our val
                prev.next = runner.next; // the previous connection will change from our runner (current node) to our next node
                return true; /// return true
            }
            runner = runner.next; //move through the list
            prev = runner; //assign second runner to this node for reference 
        }
        return false;
    };

    /** 
     * BONUS
     * Adds the given value before a specified value and returns confirmation
     * 
     * @param {any} insertVal the value to insert
     * @param {any} beforeVal the value to prepend to
     * @returns {boolean} confirmation of success
     */

    prepend(insertVal, beforeVal) {
        if (this.head === null) {
            return false;
        }
        const node = new SLLNode(insertVal);
        if (this.head.val === beforeVal) {
            let temp = this.head;
            this.head = node;
            node.next = temp;
            return true;
        }
        let runner = this.head;
        while (runner !== null) {
            if (runner.next.val === beforeVal) {
                let temp = runner.next;
                runner.next = node;
                node.next = temp;
                return true;
            }
            runner = runner.next;
        }
    }
    logTail() {
        if (this.head) {
            console.log(this.tail);
        }
    }
}




const list = new SLL();
list.insertAtBack(1);
// 1

console.log(list.secondToLast()); // should log null

list
    .insertAtBack(2)
    .insertAtBack(3)
    .insertAtBack(4);
// 1 -> 2 -> 3 -> 4

list.logTail();
// console.log(list.secondToLast()); // should log 3
// console.log(list.removeVal(10)); // should log false

// console.log(list.prepend(5, 3)); // should log true
// // 1 -> 2 -> 5 -> 3 -> 4

// console.log(list.head.next.next.val); // should log 5

