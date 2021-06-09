# 核心规范

> 术语说明
>> 文档: markdown文档

## 基础概念

### 字符集和行

1. 字符

    1. 规定字符中的字符就是Unicode代码点(code point)
    2. 不规定字符存储的编码格式,不处理字节,而是处理代码点

2. 换行

    1. line: 任意多个(包括0)非(U+000A|U+000D)字符构成的序列,以'line ending'结尾
    2. line ending: U+000A(\n), U+000D(\r), U+000DU+000A(\r\n), \r\n优先级高于\r
    3. blank line: 行由0个字符序列构成,或者只存在U+0020(空格),U+0009(制表符)字符

3. 字符类

    1. 空格(space): U+0020
    2. 空白字符(whitespace character): U+0020(space), U+0009(tab), U+000A(newline), U+000B(line tabulation), U+000C(form feed), U+000D(carriage return)
    3. Unicode空白字符: Unicode Zs, U+0009, U+000D, U+000A, U+000C
    4. 非空白字符(none-whitespace character): 除开空白字符以为的任何字符
    5. ASCII标点符号(ASCII punctuation character): `!`, `"`, `#`, `$`, `%`, `&`,
        `'`, `(`, `)`, `*`, `+`, `,`, `-`, `.`, `/` (U+0021–2F),  `:`, `;`, `<`, `=`, `>`, `?`,
        `@` (U+003A–0040), `[`, `\`, `]`, `^`, `_`, `` ` ``, (U+005B–0060), `{`, `|`, `}`, or `~` (U+007B–007E)
    6. 标点符号(punctuation character): Unicode Pc, Pd, Pe, Pf, Pi, Po, Ps

### 制表符(Tabs)

> 说明: tab在下面的代码块中使用→替代

1. 示例
    ```
    →foo→baz→→bim
    --------------------------
    <pre><code>foo→baz→→bim
    </code></pre>
    ```
2. 示例
    ```
      →foo→baz→→bim
    --------------------------
    <pre><code>foo→baz→→bim
    </code></pre>
    ```
3. 示例
    ```
        a→a
        ὐ→a
    --------------------------
    <pre><code>a→a
    ὐ→a
    </code></pre>
    ```

```````````````````````````````` example
  - foo

→bar
.
<ul>
<li>
<p>foo</p>
<p>bar</p>
</li>
</ul>
````````````````````````````````

```````````````````````````````` example
- foo

→→bar
.
<ul>
<li>
<p>foo</p>
<pre><code>  bar
</code></pre>
</li>
</ul>
````````````````````````````````

Normally the `>` that begins a block quote may be followed
optionally by a space, which is not considered part of the
content.  In the following case `>` is followed by a tab,
which is treated as if it were expanded into three spaces.
Since one of these spaces is considered part of the
delimiter, `foo` is considered to be indented six spaces
inside the block quote context, so we get an indented
code block starting with two spaces.

```````````````````````````````` example
>→→foo
.
<blockquote>
<pre><code>  foo
</code></pre>
</blockquote>
````````````````````````````````

```````````````````````````````` example
-→→foo
.
<ul>
<li>
<pre><code>  foo
</code></pre>
</li>
</ul>
````````````````````````````````


```````````````````````````````` example
    foo
→bar
.
<pre><code>foo
bar
</code></pre>
````````````````````````````````

```````````````````````````````` example
 - foo
   - bar
→ - baz
.
<ul>
<li>foo
<ul>
<li>bar
<ul>
<li>baz</li>
</ul>
</li>
</ul>
</li>
</ul>
````````````````````````````````

1. 示例
    ```
    #→Foo
    -----------------------------------------
    <h1>Foo</h1>
    ```
1. 示例
    ```
    *→*→*→
    -----------------------------------------
    <hr />
    ```

### 不安全字符

> 出于安全原因,Unicode字符`U+0000`总应该使用`U+FFFD`(replacement character)替换

## 元素类型

1. 核心概念

    > 一份文档可以被看作是一组块快构成的序列.  
    > 其中像段落,块引用,列表,标题,规则,代码块被当作块对待.  
    > 一些块内部包含行内内容, 像文本,链接,强调文本,图片,代码片段等等.

1. 优先级

    > 块的指示器字符序列的优先级总是高于行内元素的指示器序列.  
    > 文档处理第一步是解析出块序列结构(不可并行)  
    > 文档处理第二步是解析每个块中的行内元素(可并行)  
    > 文档处理的第二步骤需要依赖于第一步的解析出的块序列的某些信息(例如参考引用链接)

1. 容器块&叶块

    > 容器块: 可以包含其它块(容器块/页块)  
    > 叶块: 不能包含其它块, 只能包含行内元素  
    > 行内元素不能包含任何块, 且它必然从属于某个块

### 叶块

### 容器块

### 行元素

## 补充说明

### 附加网址

-   [官网地址](https://commonmark.org)
-   [规范地址](https://spec.commonmark.org/)
-   [文档地址](https://spec.commonmark.org/0.29/)
-   [仓库地址](https://github.com/commonmark/commonmark-spec)

### 源文档

-   version: 0.29
-   date: 2019-04-06
-   author: John MacFarlane
-   license: [CC-NC-ND 4.0](https://creativecommons.org/licenses/by-nc-nd/4.0/)
