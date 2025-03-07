﻿/*!
 * angular-slick-carousel
 * DevMark <hc.devmark@gmail.com>
 * https://github.com/devmark/angular-slick-carousel
 * Version: 3.1.4 - 2015-12-26T03:01:55.410Z
 * License: MIT
 */


'use strict';

angular
    .module('slickCarousel', [])
    //global config
    .constant('slickCarouselConfig', {
        method: {},
        event: {}
    })
    .directive('slick', [
        '$timeout', 'slickCarouselConfig', function ($timeout, slickCarouselConfig) {
            var slickMethodList, slickEventList;
            slickMethodList = ['slickGoTo', 'slickNext', 'slickPrev', 'slickPause', 'slickPlay', 'slickAdd', 'slickRemove', 'slickFilter', 'slickUnfilter', 'unslick'];
            slickEventList = ['afterChange', 'beforeChange', 'breakpoint', 'destroy', 'edge', 'init', 'reInit', 'setPosition', 'swipe'];

            return {
                scope: {
                    settings: '=',
                    enabled: '@',
                    accessibility: '@',
                    adaptiveHeight: '@',
                    autoplay: '@',
                    autoplaySpeed: '@',
                    arrows: '@',
                    asNavFor: '@',
                    appendArrows: '@',
                    prevArrow: '@',
                    nextArrow: '@',
                    centerMode: '@',
                    centerPadding: '@',
                    cssEase: '@',
                    customPaging: '&',
                    dots: '@',
                    draggable: '@',
                    fade: '@',
                    focusOnSelect: '@',
                    easing: '@',
                    edgeFriction: '@',
                    infinite: '@',
                    initialSlide: '@',
                    lazyLoad: '@',
                    mobileFirst: '@',
                    pauseOnHover: '@',
                    pauseOnDotsHover: '@',
                    respondTo: '@',
                    responsive: '=?',
                    rows: '@',
                    slide: '@',
                    slidesPerRow: '@',
                    slidesToShow: '@',
                    slidesToScroll: '@',
                    speed: '@',
                    swipe: '@',
                    swipeToSlide: '@',
                    touchMove: '@',
                    touchThreshold: '@',
                    useCSS: '@',
                    variableWidth: '@',
                    vertical: '@',
                    verticalSwiping: '@',
                    rtl: '@'
                },
                restrict: 'AE',
                link: function (scope, element, attr) {
                    //hide slider
                    angular.element(element).css('display', 'none');

                    var options, initOptions, destroy, init, destroyAndInit, currentIndex;

                    initOptions = function () {
                        options = angular.extend(angular.copy(slickCarouselConfig), {
                            enabled: scope.enabled !== 'false',
                            accessibility: scope.accessibility !== 'false',
                            adaptiveHeight: scope.adaptiveHeight === 'true',
                            autoplay: scope.autoplay === 'true',
                            autoplaySpeed: scope.autoplaySpeed != null ? parseInt(scope.autoplaySpeed, 10) : 3000,
                            arrows: scope.arrows !== 'false',
                            asNavFor: scope.asNavFor ? scope.asNavFor : void 0,
                            appendArrows: scope.appendArrows ? angular.element(scope.appendArrows) : angular.element(element),
                            prevArrow: scope.prevArrow ? angular.element(scope.prevArrow) : void 0,
                            nextArrow: scope.nextArrow ? angular.element(scope.nextArrow) : void 0,
                            centerMode: scope.centerMode === 'true',
                            centerPadding: scope.centerPadding || '50px',
                            cssEase: scope.cssEase || 'ease',
                            customPaging: attr.customPaging ? function (slick, index) {
                                return scope.customPaging({ slick: slick, index: index });
                            } : void 0,
                            dots: scope.dots === 'true',
                            draggable: scope.draggable !== 'false',
                            fade: scope.fade === 'true',
                            focusOnSelect: scope.focusOnSelect === 'true',
                            easing: scope.easing || 'linear',
                            edgeFriction: scope.edgeFriction || 0.15,
                            infinite: scope.infinite !== 'false',
                            initialSlide: parseInt(scope.initialSlide) || 0,
                            lazyLoad: scope.lazyLoad || 'ondemand',
                            mobileFirst: scope.mobileFirst === 'true',
                            pauseOnHover: scope.pauseOnHover !== 'false',
                            pauseOnDotsHover: scope.pauseOnDotsHover === "true",
                            respondTo: scope.respondTo != null ? scope.respondTo : 'window',
                            responsive: scope.responsive || void 0,
                            rows: scope.rows != null ? parseInt(scope.rows, 10) : 1,
                            slide: scope.slide || '',
                            slidesPerRow: scope.slidesPerRow != null ? parseInt(scope.slidesPerRow, 10) : 1,
                            slidesToShow: scope.slidesToShow != null ? parseInt(scope.slidesToShow, 10) : 1,
                            slidesToScroll: scope.slidesToScroll != null ? parseInt(scope.slidesToScroll, 10) : 1,
                            speed: scope.speed != null ? parseInt(scope.speed, 10) : 300,
                            swipe: scope.swipe !== 'false',
                            swipeToSlide: scope.swipeToSlide === 'true',
                            touchMove: scope.touchMove !== 'false',
                            touchThreshold: scope.touchThreshold ? parseInt(scope.touchThreshold, 10) : 5,
                            useCSS: scope.useCSS !== 'false',
                            variableWidth: scope.variableWidth === 'true',
                            vertical: scope.vertical === 'true',
                            verticalSwiping: scope.verticalSwiping === 'true',
                            rtl: scope.rtl === 'true'
                        }, scope.settings);

                    };

                    destroy = function () {
                        var slickness = angular.element(element);
                        if (slickness.hasClass('slick-initialized')) {
                            slickness.remove('slick-list');
                            slickness.slick('unslick');
                        }

                        return slickness;
                    };

                    init = function () {
                        initOptions();

                        var slickness = angular.element(element);

                        if (angular.element(element).hasClass('slick-initialized')) {
                            if (options.enabled) {
                                return slickness.slick('getSlick');
                            } else {
                                destroy();
                            }
                        } else {
                            angular.element(element).css('display', 'block');

                            if (!options.enabled) {
                                return;
                            }
                            // Event
                            slickness.on('init', function (event, slick) {
                                if (typeof options.event.init !== 'undefined') {
                                    options.event.init(event, slick);
                                }
                                if (typeof currentIndex !== 'undefined') {
                                    return slick.slideHandler(currentIndex);
                                }
                            });
                            $timeout(function () {
                                slickness.slick(options);
                            });
                        }

                        scope.internalControl = options.method || {};

                        // Method
                        slickMethodList.forEach(function (value) {
                            scope.internalControl[value] = function () {
                                var args;
                                args = Array.prototype.slice.call(arguments);
                                args.unshift(value);
                                slickness.slick.apply(element, args);
                            };
                        });

                        // Event
                        slickness.on('afterChange', function (event, slick, currentSlide, nextSlide) {
                            currentIndex = currentSlide;
                            if (typeof options.event.afterChange !== 'undefined') {
                                scope.$apply(function () {
                                    options.event.afterChange(event, slick, currentSlide, nextSlide);
                                });
                            }
                        });

                        slickness.on('beforeChange', function (event, slick, currentSlide, nextSlide) {
                            if (typeof options.event.beforeChange !== 'undefined') {
                                scope.$apply(function () {
                                    options.event.beforeChange(event, slick, currentSlide, nextSlide);
                                });
                            }
                        });

                        slickness.on('reInit', function (event, slick) {
                            if (typeof options.event.reInit !== 'undefined') {
                                scope.$apply(function () {
                                    options.event.reInit(event, slick);
                                });
                            }
                        });

                        if (typeof options.event.breakpoint !== 'undefined') {
                            slickness.on('breakpoint', function (event, slick, breakpoint) {
                                scope.$apply(function () {
                                    options.event.breakpoint(event, slick, breakpoint);
                                });
                            });
                        }
                        if (typeof options.event.destroy !== 'undefined') {
                            slickness.on('destroy', function (event, slick) {
                                scope.$apply(function () {
                                    options.event.destroy(event, slick);
                                });
                            });
                        }
                        if (typeof options.event.edge !== 'undefined') {
                            slickness.on('edge', function (event, slick, direction) {
                                scope.$apply(function () {
                                    options.event.edge(event, slick, direction);
                                });
                            });
                        }

                        if (typeof options.event.setPosition !== 'undefined') {
                            slickness.on('setPosition', function (event, slick) {
                                scope.$apply(function () {
                                    options.event.setPosition(event, slick);
                                });
                            });
                        }
                        if (typeof options.event.swipe !== 'undefined') {
                            slickness.on('swipe', function (event, slick, direction) {
                                scope.$apply(function () {
                                    options.event.swipe(event, slick, direction);
                                });
                            });
                        }
                    };

                    destroyAndInit = function () {
                        destroy();
                        init();
                    };

                    element.one('$destroy', function () {
                        destroy();
                    });

                    return scope.$watch('settings', function (newVal, oldVal) {
                        if (newVal !== null) {
                            return destroyAndInit();
                        }
                    }, true);

                }
            };
        }
    ]);
