var blazejewicz;
(function (blazejewicz) {
    var cssPropertiesSupport;
    (function (cssPropertiesSupport) {
        function getPropertyValue(element, propertyName) {
            var computedStyle = getComputedStyle(element);
            return computedStyle.getPropertyValue(propertyName).trim();
        }
        cssPropertiesSupport.getPropertyValue = getPropertyValue;
        function getPropertyValueWithSelector(selector, propertyName) {
            var element = document.querySelector(selector);
            if (element)
                return getPropertyValue(element, propertyName);
            return "";
        }
        cssPropertiesSupport.getPropertyValueWithSelector = getPropertyValueWithSelector;
        function getRootPropertyValue(propertyName) {
            return getPropertyValue(document.documentElement, propertyName);
        }
        cssPropertiesSupport.getRootPropertyValue = getRootPropertyValue;
        function removeProperty(element, propertyName) {
            if (element instanceof HTMLElement) {
                return element.style.removeProperty(propertyName).trim();
            }
            return "";
        }
        cssPropertiesSupport.removeProperty = removeProperty;
        function removePropertyWithSelector(selector, propertyName) {
            var element = document.querySelector(selector);
            if (element)
                return removeProperty(element, propertyName);
            return "";
        }
        cssPropertiesSupport.removePropertyWithSelector = removePropertyWithSelector;
        function removeRootProperty(propertyName) {
            return removeProperty(document.documentElement, propertyName);
        }
        cssPropertiesSupport.removeRootProperty = removeRootProperty;
        function setProperty(element, propertyName, value, priority) {
            if (element instanceof HTMLElement)
                element.style.setProperty(propertyName, value, priority);
        }
        cssPropertiesSupport.setProperty = setProperty;
        function setPropertyWithSelector(selector, propertyName, value, priority) {
            var element = document.querySelector(selector);
            if (element)
                setProperty(element, propertyName, value, priority);
        }
        cssPropertiesSupport.setPropertyWithSelector = setPropertyWithSelector;
        function setRootProperty(propertyName, value, priority) {
            setProperty(document.documentElement, propertyName, value, priority);
        }
        cssPropertiesSupport.setRootProperty = setRootProperty;
    })(cssPropertiesSupport = blazejewicz.cssPropertiesSupport || (blazejewicz.cssPropertiesSupport = {}));
})(blazejewicz || (blazejewicz = {}));
//# sourceMappingURL=css-properties-support.js.map