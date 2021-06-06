module.exports = {
  env: {
    browser: true,
    es2021: true,
  },
  extends: ["prettier", "eslint:recommended", "plugin:react/recommended"],
  parserOptions: {
    ecmaFeatures: {
      jsx: true,
    },
    ecmaVersion: 12,
    sourceType: "module",
  },
  plugins: ["prettier"],
  rules: {
    "no-unused-vars": 0,
    "react/prop-types": 0,
    "prettier/prettier": 0,
    "react/react-in-jsx-scope": "off",
    "react/jsx-filename-extension": [1, { extensions: [".js", ".jsx"] }],
  },
};
