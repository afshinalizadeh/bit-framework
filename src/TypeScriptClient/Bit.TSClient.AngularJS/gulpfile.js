﻿/// <binding AfterBuild='less' />
var gulp = require("gulp");
var less = require("gulp-less");

gulp.task("less", function less() {
    gulp.src(["./contents/styles/*.less"])
        .pipe(less())
        .pipe(gulp.dest("./contents/styles/"));
});
