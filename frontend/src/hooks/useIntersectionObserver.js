import { useCallback, useEffect, useRef, useState } from "react";

const DEFAULT_ROOT_MARGIN = "0px";
const DEFAULT_THRESHOLD = [0];

function useIntersectionObserver(args) {
  const rootMargin = args?.rootMargin ?? DEFAULT_ROOT_MARGIN;
  const threshold = args?.threshold ?? DEFAULT_THRESHOLD;

  const nodeRef = useRef(null);
  const rootRef = useRef(null);
  const observerRef = useRef(null);

  const [entry, setEntry] = useState();

  const unobserve = useCallback(() => {
    // Disconnect the current observer (if there is one)
    const currentObserver = observerRef.current;
    currentObserver?.disconnect();
    observerRef.current = null;
  }, []);

  useEffect(() => {
    return () => {
      // We disconnect the observer on unmount to prevent memory leaks etc.
      unobserve();
    };
  }, [unobserve]);

  const observe = useCallback(() => {
    const node = nodeRef.current;
    if (node) {
      const root = rootRef.current;
      const options = { root, rootMargin, threshold };
      // Create a observer for current "node" with given options.
      const observer = new IntersectionObserver(([newEntry]) => {
        setEntry(newEntry);
      }, options);
      observer.observe(node);
      observerRef.current = observer;
    }
  }, [rootMargin, threshold]);

  const initializeObserver = useCallback(() => {
    unobserve();
    observe();
  }, [observe, unobserve]);

  const refCallback = useCallback(
    (node) => {
      nodeRef.current = node;
      initializeObserver();
    },
    [initializeObserver]
  );

  const rootRefCallback = useCallback(
    (rootNode) => {
      rootRef.current = rootNode;
      initializeObserver();
    },
    [initializeObserver]
  );

  return [refCallback, { entry, rootRef: rootRefCallback }];
}

export default useIntersectionObserver;
