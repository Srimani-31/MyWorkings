class Stopwatch {
 constructor() {
    this.startTime = null;
    this.elapsedTime = 0;
    this.isRunning = false;
 }

 start() {
    if (this.isRunning) throw new Error('Stopwatch already started');
    this.startTime = Date.now();
    this.isRunning = true;
 }

 pause() {
    if (!this.isRunning) throw new Error('Stopwatch is not started');
    this.elapsedTime += Date.now() - this.startTime;
    this.isRunning = false;
 }

 resume() {
    if (this.isRunning) throw new Error('Stopwatch already started');
    this.startTime = Date.now();
    this.isRunning = true;
 }

 stop() {
    if (!this.isRunning) throw new Error('Stopwatch is not started');
    this.pause();
    this.elapsedTime = 0;
 }

 getElapsedTime() {
    if (this.isRunning) {
      return this.elapsedTime + (Date.now() - this.startTime);
    } else {
      return this.elapsedTime;
    }
 }
}

export default Stopwatch;