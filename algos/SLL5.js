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
     * Combines the list with a given list, lengthening it.
     * 
     * @param {SLL} otherList the list to concatenate it to
     * @returns {SLL} the original (lengthened) list
     */

    concat(otherList) {
        // your code here

        if (!this.head) {
            this.head = otherList.head;
        }
        let runner = this.head;
        while (runner.next) {
            runner = runner.next;
        }
        runner.next = otherList.head;
        return this;
    }


    /**
     * Moves the minimum value to the front of the list.
     * 
     * @returns {SLL} the original (modified) list
     */

    moveMinToFront() {
        // your code here
        if (!this.head) {
            return this;
        }

        let prev;
        let min = this.head
        let runner = this.head;

        while (runner != null) {
            if (runner.next < min.val) {
                min = runner.next;
                prev = runner;
            }
            runner = runner.next;
        }
        let oldHead = this.head
        this.head = min;
        prev.next = min.next;
        min.next = oldHead;
        return this;
    }

    /**
     * Splits the list into two lists, the second starting at the given value.
     * 
     * @param {any} val the value to split on
     * @returns {SLL} the second list
     */

    splitOnVal(val) {
        // your code here
        //creat newList
        // loop through and find val
        // val = newList.head
        // prev.next = null
    }
}

const list1 = new SLL();
list1.insertAtBack(1).insertAtBack(2);
// 1 -> 2

const list2 = new SLL();
list2.insertAtBack(3).insertAtBack(4);
// 3 -> 4

// list1.concat(list2);
// // 1 -> 2 -> 3 -> 4
// for (let i = 0; i < list1.length; i++) {
//     console.log(list1[i].val);
// }


// console.log(list1.head.next.next.next.val); // should log 4

list1.insertAtBack(0);
// 1 -> 2 -> 3 -> 4 -> 0

list1.moveMinToFront();
// 0 -> 1 -> 2 -> 3 -> 4

// console.log(list1.head.val); // should log 0

// const secondList = list1.splitOnVal(2);
// // 0 -> 1
// // 2 -> 3 -> 4

// console.log(list1.head.next.next); // should log null
// console.log(secondList.head.val); // should log 2

