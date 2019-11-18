namespace blazejewicz.cssPropertiesSupport {
    export function getPropertyValue(element: Element, propertyName: string): string {
        const computedStyle = getComputedStyle(element);
        return computedStyle.getPropertyValue(propertyName).trim();
    }

    export function getPropertyValueWithSelector(selector: string, propertyName: string): string {
        const element = document.querySelector(selector);
        if (element) return getPropertyValue(element, propertyName);
        return "";
    }

    export function getRootPropertyValue(propertyName: string): string {
        return getPropertyValue(document.documentElement, propertyName);
    }

    export function removeProperty(element: Element, propertyName: string): string {
        if (element instanceof HTMLElement) {
            return element.style.removeProperty(propertyName).trim();
        }
        return "";
    }

    export function removePropertyWithSelector(selector: string, propertyName: string): string {
        const element = document.querySelector(selector);
        if (element) return removeProperty(element, propertyName);
        return "";
    }

    export function removeRootProperty(propertyName: string): string {
        return removeProperty(document.documentElement, propertyName);
    }

    export function setProperty(element: Element, propertyName: string, value: string, priority: string) {
        if (element instanceof HTMLElement) element.style.setProperty(propertyName, value, priority);
    }

    export function setPropertyWithSelector(selector: string, propertyName: string, value: string, priority: string) {
        const element = document.querySelector(selector);
        if (element) setProperty(element, propertyName, value, priority);
    }

    export function setRootProperty(propertyName: string, value: string, priority: string) {
        setProperty(document.documentElement, propertyName, value, priority);
    }
}